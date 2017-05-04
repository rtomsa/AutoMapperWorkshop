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
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDto>());
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

            order.AddOrderLineItem(product, 1);            

            var dto = Mapper.Map<Order, OrderDto>(order);

            Console.Out.WriteLine(JsonConvert.SerializeObject(order, Formatting.Indented));
            Console.Out.WriteLine(JsonConvert.SerializeObject(dto, Formatting.Indented));            
        }
    }
}
