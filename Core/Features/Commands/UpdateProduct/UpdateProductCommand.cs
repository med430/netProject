using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.Commands.UpdateProduct
{
    public record UpdateProductCommand(int Id, string Name) : IRequest<Product>;
}
