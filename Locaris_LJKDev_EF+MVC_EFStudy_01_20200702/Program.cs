using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locaris_LJKDev_EF_MVC_EFStudy_01_20200702
{
    class Program
    {
        static void Main(string[] args)
        {   
            //思想：操作数据库，就像操作表实体一样！！

            //00_声明一个EF的上下文   GC:没有引用的时候，才会自动删除！
            LJK_SQLServerDBEntities dbContext = new LJK_SQLServerDBEntities();
            //运行时更改连接字符串
            string connectionConnectionString = dbContext.Database.Connection.ConnectionString;

            //01_声明一个UserInfo实体
            //User_Info userInfo = new User_Info()
            //{
            //    User_Name = "DK_88888",
            //    User_Age = 20,
            //    User_Pwd = 111222,
            //    User_ID = 1076
            //};

            #region 02添加操作
            //02 告诉Ef，对实体做一个插入操作
            // dbContext.User_Info.Add(userInfo);
            #endregion

            #region 03修改操作
            //update User_Info set User_Name="DK_8888" where User_Id=1098
            //03_01 告诉上下文，把实体更新操作
            //dbContext.Entry<User_Info>(userInfo).State=EntityState.Modified;

            //03_02_01 强类型方式，只修改某个列
            // dbContext.User_Info.Attach(userInfo); //附加上下文里面来管理
            //dbContext.Entry<User_Info>(userInfo).Property<string>(u=>u.User_Name).IsModified=true;

            //03_02_01 弱类型方式，只修改某个列
            //dbContext.Entry<User_Info>(userInfo).Property("User_Name").IsModified = true;
            //注：修改和删除的时候,userInfo指定Id
            #endregion

            #region 04_01 查询操作
            //把用户表里面的所有数据打印一遍
            //foreach (User_Info userInfo in dbContext.User_Info)
            //{
            //    string strUserInfo = string.Format("用户的Id为：{0}，用户的姓名为：{1}，用户的年龄为：{2}，用户的密码为：{3}",
            //                                    +userInfo.User_ID,userInfo.User_Name,userInfo.User_Age,userInfo.User_Pwd);
            //    Console.WriteLine(strUserInfo);
            //}
            #endregion

            #region 04_02 linq查询操作
            //linq表达式
            var temp = from u in dbContext.User_Info//通过u遍历User_Info集合
                       where u.User_ID > 1060
                       select u;

            foreach (User_Info userInfo in temp)
            {
                string strUserInfo = string.Format("用户的Id为：{0}，用户的姓名为：{1}，用户的年龄为：{2}，用户的密码为：{3}",
                                                +userInfo.User_ID, userInfo.User_Name, userInfo.User_Age, userInfo.User_Pwd);
                Console.WriteLine(strUserInfo);
            }
            #endregion

            //09 告诉上下文，把实体的变化保存到数据库里面去
            //dbContext.SaveChanges();         //此时才能真正影响数据库，执行Sql脚本。此方法为批量操作！
            Console.ReadKey();

        }
    }
}
