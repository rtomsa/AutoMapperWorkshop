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
                .ForMember(dest => dest.Total, opt => opt.MapFrom(x => x.OrderLineItems.Sum(y => y.Product.Price * y.Quantity)))
            );
        }

        /// <summary>
        /// Priklad zplostovani z rozsahleho objektu Order
        /// do mnohem mensiho OrderDto
        /// </summary>
        static void flattening()
        {
            var order = new Order { Customer = new Customer { Name = "Petr Paleček" } };

            var product1 = new Product{ Name = "Sluchátka", Price = 500m, };
            var product2 = new Product { Name = "Televize", Price = 8000m, };

            order.AddOrderLineItem(product1, 2);
            order.AddOrderLineItem(product2, 1);

            var dto = Mapper.Map<Order, OrderDto>(order);

            Console.Out.WriteLine(JsonConvert.SerializeObject(order, Formatting.Indented));
            Console.Out.WriteLine(JsonConvert.SerializeObject(dto, Formatting.Indented));            
        }
    }
}
