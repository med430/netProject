using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _repo;

        public UpdateProductCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repo.GetByIdAsync(request.Id);
            if(product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }
            product.Name = request.Name;
            return product;
        }
    }
}
