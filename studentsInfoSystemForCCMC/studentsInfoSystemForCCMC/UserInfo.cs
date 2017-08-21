using System;
using SQLite;

namespace studentsInfoSystemForCCMC
{

	[Table("TimeTable")]
	public class TimeTable
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		/*外部キー*/
		[Indexed]
		public int UserInfoID { get; set; }
		[Indexed]
		public int WeekDaysID { get; set; }
		[Indexed]
		public int UserTeacherID { get; set; }
	}

    /*********************学生情報*********************/
    [Table("UserInfo")]
    public class UserInfo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(6)]
        public string LoginIdentity { get; set; }

        [MaxLength(16)]
        public string LoginPassword { get; set; }

        [MaxLength(64)]
        public string UserName { get; set; }

        [MaxLength(6)]
        public string UserSex { get; set; }

        [MaxLength(8)]
        public string UserBirthday { get; set; }

        [MaxLength(32)]
        public string UserNationality { get; set; }

        //外部キー
        public int UserClassID { get; set; }

        public override string ToString()
        {
            string returnData = string.Format("[UserInfo: ID={0}, LoginIdentity={1}, " +
                                              "LoginPassword={2}], UserName={3}, UserSex={4}," +
                                              "UserBirthday={5}, UserNationality={6}",
                                              ID, LoginIdentity, LoginPassword, UserName, UserSex,
                                              UserSex, UserBirthday, UserNationality);
            return returnData;
        }
    }

    [Table("UserClass")]
    public class UserClass
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string ClassName { get; set; }
    }


    /*********************学校スケジュールのフィルド*********************/
    [Table("WeekDays")]
    public class WeekDays
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int ScheduleID { get; set; }
    }

    [Table("Schedule")]
    public class Schedule
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
    }


    /**********************先生フィルド**********************/
    [Table("UserTeacher")]
    public class UserTeacher
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public int TperiodID { get; set; }
        [Indexed]
        public int SubjectsID { get; set; }
        [Indexed]
        public int LectureRoom { get; set; }
    }

    [Table("TPeriod")]
    public class TPeriod
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
    }

    [Table("Subjects")]
    public class Subjects
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
    }

    [Table("LectureRoom")]
    public class LectureRoom
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
    }

}
