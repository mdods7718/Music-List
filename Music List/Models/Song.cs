using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Music_List.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        [Required]// makes it not null
        public string Title { get; set; }
        [DisplayName("Author Name")]
        [Required]
        public string Author { get; set; }

    }
}
