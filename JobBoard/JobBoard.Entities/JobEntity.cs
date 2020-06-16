using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.Entities
{
    public class JobEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }
        [StringLength(100)]
        [Required]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }

    }
}
