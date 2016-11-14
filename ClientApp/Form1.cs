using System;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        private Client _client;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnectServer_Click(object sender, EventArgs e)
        {
            _client = new Client();
            _client.ConnectToServer(200);

            _client.GetInfoFromServer(mainDataGridView, cmbTables, lblText);

            btnQuery1.Enabled = true;
            btnQuery2.Enabled = true;
            btnQuery3.Enabled = true;
            btnSelectTable.Enabled = true;
            btnConnectServer.Enabled = false;
            btnDisconnectServer.Enabled = true;
        }

        private void btnSelectTable_Click(object sender, EventArgs e)
        {
            _client.SelectTable(mainDataGridView, cmbTables, lblText);
        }

        private void btnDisconnectServer_Click(object sender, EventArgs e)
        {
            mainDataGridView.DataSource = null;
            cmbTables.Items.Clear();

            _client.DisconnectFromServer();

            lblText.Text = @"Table: ";

            btnQuery1.Enabled = false;
            btnQuery2.Enabled = false;
            btnQuery3.Enabled = false;
            btnSelectTable.Enabled = false;
            btnConnectServer.Enabled = true;
            btnDisconnectServer.Enabled = false;
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            //_client.UpdateTable(mainDataGridView);
        }

        private void btnQuery1_Click(object sender, EventArgs e)
        {
            lblText.Text = @"Query: Вывести всех студентов, которые учатся на Системной инженерии";
            var query = @"SELECT pers.Surname + ' ' + pers.Name + coalesce(' ' + pers.Patronymic, '') as [ФИО]
	                FROM PERSON pers
	                INNER JOIN STUDENT stud
	                ON stud.Student_ID = pers.Student_ID
	                INNER JOIN STUDENT_GROUP stud_group
	                ON stud_group.Student_ID = stud.Student_ID
	                INNER JOIN GROUPS groups
	                ON groups.Group_ID = stud_group.Group_ID
	                INNER JOIN SPECIALITY spec
	                ON spec.Speciality_ID = groups.Speciality_ID
	                WHERE spec.Speciality_name = N'Системная инженерия'
	                ORDER BY [ФИО]";
            _client.ExecuteQuery(mainDataGridView, query);
        }

        private void btnQuery2_Click(object sender, EventArgs e)
        {
            lblText.Text = @"Query: Вывести всех студентов, которые учатся только на 5";
            var query = @"SELECT pers.Surname + ' ' + pers.Name + coalesce(' ' + pers.Patronymic, '') as [ФИО]
	                FROM PERSON pers
	                INNER JOIN STUDENT stud
	                ON stud.Student_ID = pers.Student_ID
	                INNER JOIN STUDENT_MARKS stud_marks
	                ON stud_marks.Student_ID = stud.Student_ID
	                INNER JOIN SMARK mark
	                ON mark.Mark_ID = stud_marks.Mark_ID
	                GROUP BY pers.Surname + ' ' + pers.Name + coalesce(' ' + pers.Patronymic, '')
	                HAVING AVG(stud_marks.Mark_ID) = 5
	                ORDER BY [ФИО]";
            _client.ExecuteQuery(mainDataGridView, query);
        }

        private void btnQuery3_Click(object sender, EventArgs e)
        {
            lblText.Text = @"Query: Вывести указ и наказание для студентов, которые опоздали 17 мая";
            var query = @"SELECT pers.Surname + ' ' + pers.Name + coalesce(' ' + pers.Patronymic, '') as [ФИО],
                    viol.Violation_date as [Дата нарушения],
	                viol_kind.Violation_kind_name as [Нарушение],
	                pun_kind.Punish_kind_name as [Наказание],
	                ord_kind.Order_kind_name as [Указ],
	                ord.Order_text as [Текст указа]
                    FROM PERSON pers
                    INNER JOIN VIOLATION viol
                    ON viol.Person_ID = pers.Person_ID
                    INNER JOIN SPUNISH_KIND pun_kind
                    ON pun_kind.Punish_kind_ID = viol.Punish_kind_ID
                    INNER JOIN SVIOLATION_KIND viol_kind
                    ON viol_kind.Violation_kind_ID = viol.Violation_kind_ID
                    INNER JOIN ORDERS ord
                    ON ord.Order_ID = viol.Order_ID
                    INNER JOIN SORDER_KIND ord_kind
                    ON ord_kind.Order_kind_ID = ord.Order_kind_ID
                    WHERE viol_kind.Violation_kind_name = N'Опоздание' AND viol.Violation_date = '2016-05-17'
                    ORDER BY [ФИО]";
            _client.ExecuteQuery(mainDataGridView, query);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.DisconnectFromServer();
        }
    }
}