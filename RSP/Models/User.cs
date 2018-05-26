/**
 * @(#) User.cs
 */

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RSP.Models
{
    public class User : IdentityUser
    {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public int last_log_date { get; set; }

        public void addUser(  )
        {
            
        }
        
        public void removeUser( int id )
        {
            
        }
        
        public void updateUser( User user )
        {
            
        }
        
        public void getUsers(  )
        {
            
        }
        
        public void getUser( int id )
        {
            
        }
        
    }
    
}
