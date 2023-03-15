using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(50)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The CPF is Required")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "The DateOfBirth is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
    }
}
