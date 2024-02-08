using Shop.Core.Entities;

namespace Shop.Business.Interface;

public interface IInvoiceService
{
    bool CreateInvoice(List<int> productInvoiceIds, int cardId, int userId);
}
