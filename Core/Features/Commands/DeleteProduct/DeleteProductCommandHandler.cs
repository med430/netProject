using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly IProductRepository _repo;

        public DeleteProductCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteAsync(request.Id);
        }
    }
}
