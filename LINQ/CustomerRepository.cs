using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class CustomerRepository
    {

        public Customer Find(List<Customer> customerList, int customerId)
        {
            Customer foundCustomer = null;

            //foreach (var c in customerList)
            //{
            //    if (c.CustomerId == customerId)
            //    {
            //        foundCustomer = c;
            //        break;
            //    }
            //}

            //var query = from c in customerList                      //Query Syntax
            //            where c.CustomerId == customerId
            //            select c;

            //foundCustomer = query.First();

            foundCustomer = customerList.FirstOrDefault(c =>    //Method Syntax
            c.CustomerId == customerId);


            //foundCustomer = customerList.Where(c =>
            //c.CustomerId == customerId)
            //    .Skip(1)                  //Chaining
            //    .FirstOrDefault();

            return foundCustomer;
        }


        public List<Customer> Retrieve()
        {

            List<Customer> custList = new List<Customer>
       {
        new Customer()
        {
            CustomerId = 1,
            FirstName = "John",
            LastName = "Smith",
            EmailAddress = "some.email@domain.com",
            CustomerTypeId = 1
        },
         new Customer()
          {
            CustomerId = 2,
            FirstName = "Froddo",
            LastName = "Baggins",
            EmailAddress = "fb@hob.com",
            CustomerTypeId = null
        },
         new Customer()
          {
            CustomerId = 3,
            FirstName = "Tom",
            LastName = "Hanks",
            EmailAddress = "th@actor.com",
            CustomerTypeId = 2
        }
        };
            return custList;
        }

        public IEnumerable<Customer> SortByName(List<Customer> customerList)
        {
            return customerList.OrderBy(C => C.LastName)
                .ThenBy(c => c.FirstName);
        }

        public IEnumerable<Customer> SortByNameInReverse(List<Customer> customerList)
        {
            //return customerList.OrderByDescending(c => c.LastName)
            //    .ThenByDescending(c => c.FirstName);

            return SortByName(customerList).Reverse();
        }

        public IEnumerable<Customer> SortByType(List<Customer> customerList)
        {
            //return customerList.OrderBy(c => c.CustomerTypeId);
            return customerList.OrderByDescending(c => c.CustomerTypeId.HasValue)
                .ThenBy(c => c.CustomerTypeId);
        }
    }
}
