using System;
using ITDocumentation.Data;
using Microsoft.Identity.Client;

namespace ITDocumentation
{
    public class Initializer
    {

        ApplicationDbContext dbContext;
        ActiveDirectoryCon activeDirectory;

        public Initializer(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            activeDirectory = new ActiveDirectoryCon();
        }


        public void initDepartments()
        {
            //USE THIS TO GET DEPARTMENTS FROM ACTIVE DIRECTORY
            //List<string> departments = activeDirectory.getAllDepartments();

            //USE THIS TO GET DEPARTMENTS FROM A LIST
             List<string> departments = new List<string>();
                departments.Add("INFORMATION TECHNOLOGY");
                departments.Add("ACCOUNTING");
                departments.Add("BUSINESS DEVELOPMENT");

            if (departments != null)
            {
                foreach (var departmentName in departments)
                {
                    if (dbContext.Department.Any(d => d.Name == departmentName) == false)
                    {
                        Department department = new Department();
                        department.Name = departmentName;
                        department.DateTime = DateTime.Now;
                        department.AuthorName = "System";
                        dbContext.Add(department);
                        dbContext.SaveChanges();
                    }
                }
            }


        }

        public void initAdminSubdepartment(){
            if (dbContext.Subdepartment.Any(d => d.Name == "Admin") == false)
            {
                Subdepartment admin = new Subdepartment();
                admin.Name = "Admin";
                admin.DateTime = DateTime.Now;
                admin.AuthorName = "System";
                admin.DepartmentID = dbContext.Department.First(d => d.Name == "INFORMATION TECHNOLOGY").ID;
                dbContext.Add(admin);
                dbContext.SaveChanges();
            }
        }

        public void initSubdepartments(string departmentName){
            List<string> subdepartments = new List<string>();
            subdepartments.Add("Software Development");
            subdepartments.Add("Network Administration");
            subdepartments.Add("Database Administration");
            foreach (var subdepartment in subdepartments)
            {
                if(dbContext.Subdepartment.Any(d => d.Name == subdepartment) == false){
                    Subdepartment sub = new Subdepartment();
                    sub.Name = subdepartment;
                    sub.DateTime = DateTime.Now;
                    sub.AuthorName = "System";
                    sub.DepartmentID = dbContext.Department.First(d => d.Name == departmentName).ID;
                    dbContext.Add(sub);
                    dbContext.SaveChanges();

                }
            }

        }

    public void initUserSubdepartments(string departmentName, string subdepartmentName,string username){
        if(dbContext.UserSubdepartment.Any(d => d.Username == username) == false){
            UserSubdepartment userSub = new UserSubdepartment();
            userSub.Username = username;
            userSub.SubdepartmentID = dbContext.Subdepartment.First(d => d.Name == subdepartmentName).ID;
            userSub.DepartmentID = dbContext.Department.First(d => d.Name == departmentName).ID;
            dbContext.Add(userSub);
            dbContext.SaveChanges();
        }


    }


        public void initMenuPages()
        {
            Subdepartment admin = dbContext.Subdepartment.First(d => d.Name == "Admin");
            List<SinglePage> requiredPages = dbContext.SinglePage.Where(s => s.SubdepartmentID == admin.ID).ToList();
            foreach (var page in requiredPages)
            {

                if (!dbContext.MenuItem.Any(i => i.Name == page.Name))
                {

                    MenuItem item = new MenuItem();
                    item.Name = page.Name;
                    item.PageID = page.ID;
                    item.AuthorName = "System";
                    item.DateTime = DateTime.Now;
                    dbContext.Add(item);
                }

            }
            dbContext.SaveChanges();
        }

        public void createRequiredPages()
        {
            if (dbContext.Subdepartment.Any(d => d.Name == "Admin"))
            {
                Subdepartment admin = dbContext.Subdepartment.First(d => d.Name == "Admin");




                if (!dbContext.SinglePage.Any(s => s.Name == "SYM Master List"))
                {
                    SinglePage symList = new SinglePage();
                    symList.Name = "SYM Master List";
                    symList.AuthorName = "System";
                    symList.SubdepartmentID = admin.ID;
                    symList.DateTime = DateTime.Now;
                    symList.PageContent = "SYM Master List additional content";
                    dbContext.Add(symList);


                }

                if (!dbContext.SinglePage.Any(s => s.Name == "Server List"))
                {
                    SinglePage serverList = new SinglePage();
                    serverList.Name = "Server List";
                    serverList.AuthorName = "System";
                    serverList.SubdepartmentID = admin.ID;
                    serverList.DateTime = DateTime.Now;
                    serverList.PageContent = "Server List additional content";
                    dbContext.Add(serverList);

                }

                if (!dbContext.SinglePage.Any(s => s.Name == "Database List"))
                {
                    SinglePage databaseList = new SinglePage();
                    databaseList.Name = "Database List";
                    databaseList.AuthorName = "System";
                    databaseList.SubdepartmentID = admin.ID;
                    databaseList.DateTime = DateTime.Now;
                    databaseList.PageContent = "Database List additional content";
                    dbContext.Add(databaseList);

                }

                if (!dbContext.SinglePage.Any(s => s.Name == "Manual Procedures"))
                {
                    SinglePage manualProc = new SinglePage();
                    manualProc.Name = "Manual Procedures";
                    manualProc.AuthorName = "System";
                    manualProc.SubdepartmentID = admin.ID;
                    manualProc.DateTime = DateTime.Now;
                    manualProc.PageContent = "Manual Procedures additional content";
                    dbContext.Add(manualProc);

                }

                if (!dbContext.SinglePage.Any(s => s.Name == "Core Values"))
                {
                    SinglePage departmentAbout = new SinglePage();
                    departmentAbout.Name = "Core Values";
                    departmentAbout.AuthorName = "System";
                    departmentAbout.SubdepartmentID = admin.ID;
                    departmentAbout.DateTime = DateTime.Now;
                    departmentAbout.PageContent = "Write about your department";
                    dbContext.Add(departmentAbout);

                }

                dbContext.SaveChanges();
            } 

        }

        public void initRoles()
        {
            Role admin = new Role();
            admin.RoleName = "ADMIN";

            Role editor = new Role();
            editor.RoleName = "EDITOR";

            Role regular = new Role();
            regular.RoleName = "REGULAR";

            dbContext.Role.Add(admin);
            dbContext.Role.Add(editor);
            dbContext.Role.Add(regular);
            dbContext.SaveChanges();

        }

        public void initUsers(string departmentName)
        {
            //USE THIS TO GET USERS FROM ACTIVE DIRECTORY
            //List<User> users = activeDirectory.getAllUsers(departmentName);

            //USE THIS TO GET USERS FROM A LIST
            List<User> users = new List<User>()
            {
                new User { Username = "yreyes", Name = "Yahaira Reyes" , Department = "INFORMATION TECHNOLOGY"},
                new User { Username = "ichavez", Name = "Israel Chavez", Department = "INFORMATION TECHNOLOGY" },
                new User { Username = "jdoe", Name = "John Doe", Department = "INFORMATION TECHNOLOGY"}
            };
            Department department = dbContext.Department.First(d => d.Name == departmentName.ToUpper());
            if (users != null)
            {
                foreach (var user in users)
                {
                    if (dbContext.UserRole.Any(u => u.Username == user.Username) == false)
                    {
                        UserRole userRole = new UserRole();
                        userRole.Username = user.Username ?? "";
                        userRole.Name = user.Name ?? "";
                        userRole.DepartmentID = department.ID;
                        userRole.RoleName = "REGULAR";
                        dbContext.Add(userRole);
                        dbContext.SaveChanges();
                    }
                }
            }

        }
    }
}