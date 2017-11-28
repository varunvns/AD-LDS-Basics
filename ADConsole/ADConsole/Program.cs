using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;

namespace ADConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the LDAP Link:");
            var path = Console.ReadLine();
            Console.WriteLine("Please enter the Username:");
            var username = Console.ReadLine();
            Console.WriteLine("Please enter the Password:");
            var password = Console.ReadLine();
            var directoryEntry = new DirectoryEntry(path, username,password);
            directoryEntry.RefreshCache();
            try
            {

                //    using (var context = new PrincipalContext(ContextType.Domain, "LDAP://UHG-IJSR-POC-VM:5000/CN=UHG-Brazil,OU=Admins,OU=Employees,DC=UHG"))
                //    {
                //        //ContactPrincipal
                //        using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                //        {
                //            foreach (var result in searcher.FindAll())
                //            {
                //                DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                //              Console.WriteLine("{0} {1}", de.Properties["samAccountName"].Value, de.Properties["givenName"].Value);
                //            }

                //        }
                //    }

                var directorySearcher = new DirectorySearcher(directoryEntry)
                {
                    Filter = "(&(objectClass=user))",
                    SearchScope = SearchScope.Subtree
                };
                //directorySearcher.Refres
                //directorySearcher.
                Console.WriteLine("Users:");
                foreach (SearchResult user in directorySearcher.FindAll())
                {
                    //Console.WriteLine("CN={0}, Name={1}, Path={2}, objectClass={3}", user.Properties["CN"][0], user.Properties["name"][0], user.Path, user.Properties["objectClass"][0]);
                    //if (!string.IsNullOrEmpty(user.Properties["employeeID"]?[0].ToString()))
                    //    Console.WriteLine("Employee ID: {0}", user.Properties["employeeID"][0]);
                    if (!string.IsNullOrEmpty(user.Properties["cn"]?[0].ToString()))
                        Console.WriteLine("Common Name: {0}", user.Properties["cn"][0]);
                    if (user.Properties["ou"] != null && user.Properties["ou"][0] != null && !string.IsNullOrEmpty(user.Properties["ou"][0].ToString()))
                        Console.WriteLine("Organization Unit: {0}", user.Properties["ou"][0]);
                    //if (!string.IsNullOrEmpty(user.Properties["displayName"]?[0].ToString()))
                    //    Console.WriteLine("Display Name: {0}", user.Properties["displayName"][0]);
                    //if (!string.IsNullOrEmpty(user.Properties["department"]?[0].ToString()))
                    //    Console.WriteLine("Department: {0}", user.Properties["department"][0]);
                    ////for (int i = 0; i < user.Properties["name"].Count; i++)
                    //{
                    //    Console.WriteLine(user.Properties["name"][i]);
                    //}
                    //Console.WriteLine("Object Class: ");
                    //for (int i = 0; i < user.Properties["objectClass"].Count; i++)
                    //{
                    //    Console.WriteLine(user.Properties["objectClass"][i]);
                    //}

                }
                Console.WriteLine("Users:");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + ex.StackTrace);
            }


            //#region User Creation

            //Console.WriteLine("Lets Create a User");

            //Console.WriteLine("Please enter User Name");
            //var username = Console.ReadLine();

            //Console.WriteLine("Enter User's Display Name");
            //var userFullName = Console.ReadLine();

            ////Console.WriteLine("Enter the Manager's Name");
            ////var userManager = Console.ReadLine();

            //try
            //{
            //    if (username != null)
            //    {
            //        //var userObject = directoryEntry.Children.Add($"CN={username}", "user");
            //        var userObject = directoryEntry.Children.Add("CN=username123", "user");
            //        if (userFullName != null)
            //            userObject.Properties["displayName"].Add(userFullName);
            //        //if (userManager != null)
            //        //    userObject.Properties["manager"].Add(userManager);
            //        userObject.CommitChanges();
            //    }
            //    Console.WriteLine("User Creation Successful");
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception.Message + exception.StackTrace);
            //}

            //#endregion User Creation

            Console.Read();
            Console.WriteLine("Users END");
        }
    }
}
