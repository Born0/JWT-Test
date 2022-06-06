using System.Collections.Generic;

namespace JWTTest.Models
{
    public class DataSetConst
    {
        public static List<UserModel> UserList = new List<UserModel>() {
            new UserModel() {Id=1, Name="name1", Email="user1@gmail.com",Password="pass1",Role="Student" },
            new UserModel() {Id=2, Name="name2", Email="user2@gmail.com",Password="pass2",Role="Student" },
            new UserModel() {Id=3, Name="name3", Email="user3@gmail.com",Password="pass3",Role="Student" },
            new UserModel() {Id=4, Name="name4", Email="user4@gmail.com",Password="pass4",Role="Student" },
            new UserModel() {Id=5, Name="name5", Email="user5@gmail.com",Password="pass5",Role="Teacher" }
        };
    }
}
