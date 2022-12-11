using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.WebAPI.Models
{
    public class Account
    {
        [Key]
        public Guid Id{ get; set; }

        [Required]
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User Users { get; set; }
    }
}
