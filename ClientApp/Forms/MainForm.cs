using ClientApp.Utilities;
using System;
using System.Windows.Forms;

namespace ClientApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly Client _client;

        public MainForm(Client client)
        {
            InitializeComponent();

            _client = client;
            _client.GetInfoFromServer(mainDataGridView, lstTables, lblText);
            DataCleaner.CleanDataGridView(mainDataGridView);
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            _client.UpdateTable(mainDataGridView, txtEdit, lblText);
            DataCleaner.CleanDataGridView(mainDataGridView);
        }
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SignInForm.MainFormCloseHandler(sender, e);
        }

        private void lstTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTables.SelectedIndex == -1)
                return;

            lstQueries.ClearSelected();
            lstTags.ClearSelected();

            _client.SelectTable(mainDataGridView, lstTables, lblText);
            DataCleaner.CleanDataGridView(mainDataGridView);
        }

        private void lstTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTags.SelectedIndex == -1)
                return;

            lstQueries.ClearSelected();
            lstTables.ClearSelected();

            #region Tag Queries

            var tag1 = @"SELECT pers.Surname + ' ' + pers.Name + coalesce(' ' + pers.Patronymic, '') as [ФИО],
	                viol.Violation_date as [Дата нарушения],
	                viol_kind.Violation_kind_name as [Нарушение],
	                pun_kind.Punish_kind_name as [Наказание],
	                ord_kind.Order_kind_name as [Указ],
	                ord.Order_text as [Текст указа]
	                FROM PERSON pers
	                INNER JOIN VIOLATION viol
	                ON viol.Person_ID = pers.Person_ID
	                INNER JOIN PUNISH_KIND pun_kind
	                ON pun_kind.Punish_kind_ID = viol.Punish_kind_ID
	                INNER JOIN VIOLATION_KIND viol_kind
	                ON viol_kind.Violation_kind_ID = viol.Violation_kind_ID
	                INNER JOIN ORDERS ord
	                ON ord.Orders_ID = viol.Orders_ID
	                INNER JOIN ORDER_KIND ord_kind
	                ON ord_kind.Order_kind_ID = ord.Order_kind_ID
	                ORDER BY [Нарушение]";
            var tag2 = @"SELECT pers.Surname + ' ' + pers.Name + coalesce(' ' + pers.Patronymic, '') as [ФИО],
	                spec.Speciality_name as [Специальность],
	                groups.Group_code as [Группа],
	                groups.Group_create_date as [Дата создания группы]
	                FROM PERSON pers
	                INNER JOIN STUDENT stud
	                ON stud.Student_ID = pers.Student_ID
	                INNER JOIN STUDENT_GROUP stud_group
	                ON stud_group.Student_ID = stud.Student_ID
	                INNER JOIN GROUPS groups
	                ON groups.Groups_ID = stud_group.Groups_ID
	                INNER JOIN SPECIALITY spec
	                ON spec.Speciality_ID = groups.Speciality_ID
	                ORDER BY [Группа]";
            var tag3 = @"SELECT pers.Surname + ' ' + pers.Name + coalesce(' ' + pers.Patronymic, '') as [ФИО],
	                spec.Speciality_name as [Специальность],
	                groups.Group_code as [Группа],
	                AVG(stud_marks.Mark_ID) as [Средняя оценка]
	                FROM PERSON pers
	                INNER JOIN STUDENT stud
	                ON stud.Student_ID = pers.Student_ID
	                INNER JOIN STUDENT_MARKS stud_marks
	                ON stud_marks.Student_ID = stud.Student_ID
	                INNER JOIN MARK mark
	                ON mark.Mark_ID = stud_marks.Mark_ID
	                INNER JOIN STUDENT_GROUP stud_group
	                ON stud_group.Student_ID = stud.Student_ID
	                INNER JOIN GROUPS groups
	                ON groups.Groups_ID = stud_group.Groups_ID
	                INNER JOIN SPECIALITY spec
	                ON spec.Speciality_ID = groups.Speciality_ID
	                GROUP BY pers.Surname + ' ' + pers.Name + coalesce(' ' + pers.Patronymic, ''), spec.Speciality_name, groups.Group_code
	                ORDER BY [Средняя оценка] desc";

            #endregion Tag Queries

            switch (lstTags.SelectedIndex)
            {
                case 0:
                    _client.ExecuteQuery(mainDataGridView, tag1);
                    break;

                case 1:
                    _client.ExecuteQuery(mainDataGridView, tag2);
                    break;

                case 2:
                    _client.ExecuteQuery(mainDataGridView, tag3);
                    break;

                default:
                    MessageBox.Show(@"Unexpected query!", @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
        }

        private void lstQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstQueries.SelectedIndex == -1)
                return;

            lstTables.ClearSelected();
            lstTags.ClearSelected();

            #region Queries

            var query1 = @"SELECT pers.Surname + ' ' + pers.Name + coalesce(' ' + pers.Patronymic, '') as [ФИО],
                    spec.Speciality_name as [Специальность],
	                groups.Group_code as [Группа],
	                groups.Group_create_date as [Дата создания группы]
	                FROM PERSON pers
	                INNER JOIN STUDENT stud
	                ON stud.Student_ID = pers.Student_ID
	                INNER JOIN STUDENT_GROUP stud_group
	                ON stud_group.Student_ID = stud.Student_ID
	                INNER JOIN GROUPS groups
	                ON groups.Groups_ID = stud_group.Groups_ID
	                INNER JOIN SPECIALITY spec
	                ON spec.Speciality_ID = groups.Speciality_ID
	                WHERE spec.Speciality_name = N'Системная инженерия'
	                ORDER BY [ФИО]";

            var query2 = @"SELECT pers.Surname + ' ' + pers.Name + coalesce(' ' + pers.Patronymic, '') as [ФИО],
                    AVG(stud_marks.Mark_ID) as [Средняя оценка]
	                FROM PERSON pers
	                INNER JOIN STUDENT stud
	                ON stud.Student_ID = pers.Student_ID
	                INNER JOIN STUDENT_MARKS stud_marks
	                ON stud_marks.Student_ID = stud.Student_ID
	                INNER JOIN MARK mark
	                ON mark.Mark_ID = stud_marks.Mark_ID
	                GROUP BY pers.Surname + ' ' + pers.Name + coalesce(' ' + pers.Patronymic, '')
	                HAVING AVG(stud_marks.Mark_ID) = 5
	                ORDER BY [ФИО]";

            var query3 = @"SELECT pers.Surname + ' ' + pers.Name + coalesce(' ' + pers.Patronymic, '') as [ФИО],
	                viol.Violation_date  as [Дата нарушения],
	                viol_kind.Violation_kind_name as [Нарушение],
	                pun_kind.Punish_kind_name as [Наказание],
	                ord_kind.Order_kind_name as [Указ],
	                ord.Order_text as [Текст указа]
	                FROM PERSON pers
	                INNER JOIN VIOLATION viol
	                ON viol.Person_ID = pers.Person_ID
	                INNER JOIN PUNISH_KIND pun_kind
	                ON pun_kind.Punish_kind_ID = viol.Punish_kind_ID
	                INNER JOIN VIOLATION_KIND viol_kind
	                ON viol_kind.Violation_kind_ID = viol.Violation_kind_ID
	                INNER JOIN ORDERS ord
	                ON ord.Orders_ID = viol.Orders_ID
	                INNER JOIN ORDER_KIND ord_kind
	                ON ord_kind.Order_kind_ID = ord.Order_kind_ID
	                WHERE viol_kind.Violation_kind_name = N'Опоздание' AND viol.Violation_date = '2016-05-17'
	                ORDER BY [ФИО]";

            #endregion Queries

            switch (lstQueries.SelectedIndex)
            {
                case 0:
                    _client.ExecuteQuery(mainDataGridView, query1);
                    break;

                case 1:
                    _client.ExecuteQuery(mainDataGridView, query2);
                    break;

                case 2:
                    _client.ExecuteQuery(mainDataGridView, query3);
                    break;

                default:
                    MessageBox.Show(@"Unexpected query!", @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
        }
    }
}