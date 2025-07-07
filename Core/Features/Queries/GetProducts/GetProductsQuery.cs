using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Queries.GetProducts
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;
}
