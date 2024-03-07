using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Models
{
    public class Teams //: IEnumerable
    {
        [Key]
        public Guid Team_Id { get; set; }
        public string Team_Name { get; set; }

    }
}
