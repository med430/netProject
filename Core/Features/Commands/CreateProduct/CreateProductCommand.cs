using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Commands.CreateProduct
{
    public record CreateProductCommand(string Name) : IRequest<int>;
}
