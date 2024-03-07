using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Task_Management_System.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Task_Management_System.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Task_Management_SystemUser class
public class Task_Management_SystemUser : IdentityUser
{
    [Required]
    public string Name { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }

    
}

