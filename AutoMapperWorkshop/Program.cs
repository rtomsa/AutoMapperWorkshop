using AutoMapper;
using AutoMapperWorkshop.Dto;
using AutoMapperWorkshop.Model;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace AutoMapperWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            initialize();

            flattening();

            // Stop it
            Console.In.ReadLine();
        }

        /// <summary>
        /// Initializace mapperu
        /// </summary>
        static void initialize()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDto>()
<<<<<<< HEAD
            .ForMember(
                    dest => dest.Total,
                    opt => opt.MapFrom(src => src.OrderLineItems.Sum(li => li.GetTotal()))));
=======
                .ForMember(dest => dest.Total, expression => expression.MapFrom(order => order.OrderLineItems.Sum(li => li.GetTotal()))));
>>>>>>> c19b5af290189607f7cd1ad6a0efdc3c7540cb78
        }

        /// <summary>
        /// Priklad zplostovani z rozsahleho objektu Order
        /// do mnohem mensiho OrderDto
        /// </summary>
        static void flattening()
        {
            var order = new Order
            {
                Customer = new Customer
                {
                    Name = "Petr Paleček"
                }
            };

            var product = new Product
            {
                Name = "Sluchátka",
                Price = 500m,
            };

<<<<<<< HEAD
            order.AddOrderLineItem(product, 3);
=======
            order.AddOrderLineItem(product, 1);
            order.AddOrderLineItem(new Product
            {
                Name = "xy",
                Price = 1.42m
            }, 43);
>>>>>>> c19b5af290189607f7cd1ad6a0efdc3c7540cb78

            var dto = Mapper.Map<Order, OrderDto>(order);

            Console.Out.WriteLine(JsonConvert.SerializeObject(order, Formatting.Indented));
            Console.Out.WriteLine(JsonConvert.SerializeObject(dto, Formatting.Indented));
        }
    }
}
