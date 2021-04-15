using HomeComplain.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeComplain.Data
{
    class SQLiteComplaintDBHelper
    {
        static object objLocker = new object();
        SQLiteConnection complaintDatabase;

        //create database istance 
        public SQLiteComplaintDBHelper()
        {
            //ticketDatabase = GetConnection();
            complaintDatabase.CreateTable<UserDetail>();
            complaintDatabase.CreateTable<ComplaintDetail>();
        }

        //create database istance and create the tables
        public SQLiteComplaintDBHelper(string dbPath)
        {
            complaintDatabase = new SQLiteConnection(dbPath);
            complaintDatabase.CreateTable<UserDetail>();
            complaintDatabase.CreateTable<ComplaintDetail>();
        }


        //Get user by name
        public UserDetail GetUserByName(string userName)
        {
            lock (objLocker)
            {
                return complaintDatabase.Table<UserDetail>().FirstOrDefault(x => x.FullName == userName);
            }
        }

        //user athentication with email and password
        public UserDetail GetUserAthentication(string userName, string usersPassward)
        {
            lock (objLocker)
            {
                return complaintDatabase.Table<UserDetail>().FirstOrDefault(x => x.FullName == userName && x.Password == usersPassward);
            }
        }

        //save or update user in dabase
        public int SaveOrUpdateUser(UserDetail user)
        {
            lock (objLocker)
            {
                if (user.UserID != 0)
                {
                    complaintDatabase.Update(user);
                    return user.UserID;
                }
                else
                { 
                    return complaintDatabase.Insert(user);
                }
            }
        }


        //Update Complaint  or Insert New Complaint  
        public int SaveNewComplaintOrUpdate(ComplaintDetail compDetail)
        {
            lock (objLocker)
            {
                if (compDetail.ComplaintID != 0)
                {
                    complaintDatabase.Update(compDetail);
                    return compDetail.ComplaintID;
                }
                else
                {      
                    return complaintDatabase.Insert(compDetail);
                }
            }
        }

        //get complaint list
        public IEnumerable<ComplaintDetail> GetComplaintAsync()
        {
            lock (objLocker)
            {
                return (from i in complaintDatabase.Table<ComplaintDetail>() select i).ToList();
            }
        }


        //delete User Detail
        public int DeleteSingleUser(int id)
        {
            lock (objLocker)
            {
                return complaintDatabase.Delete<UserDetail>(id);
            }
        }

    }
}
