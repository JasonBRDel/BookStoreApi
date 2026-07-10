using InventoryService.Models;
using InventoryService.Repositories.interfaces;
using MediatR;

namespace InventoryService.Features.Commands.AddBookCommand
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, BaseResponse<bool>>
    {
        //private readonly IProductRepository _productRepository;

        //public AddBookHandler(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        public async Task<BaseResponse<bool>> Handle(AddBookCommand cmd, CancellationToken cancellationToken)
        {
            //var products = await _productRepository.GetProducts(17);
            throw new NotImplementedException();
        }
    }
}
