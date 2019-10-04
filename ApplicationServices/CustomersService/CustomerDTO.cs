using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
namespace ApplicationServices.CustomersService
{
    public class CustomerDTO
    {
        public int Id { get;  set; }

        public string Name { get; set; }

        public string  Address { get; set; }

        public bool IsActive { get; set; }

        public bool  IsVaild { get
            {
                var result = new CustomerValidator()
               .Validate(this);
                return result.IsValid;
            } }
       

        public  IEnumerable<string>  Errors()
        {
           
            var result = new CustomerValidator()
                .Validate(this).Errors;
            
            return result.Select(e=> e.ErrorMessage);
        }
    }

    public class CustomerValidator : AbstractValidator<CustomerDTO>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(0, 10);
        }
    }
}