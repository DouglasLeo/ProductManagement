using System;
using System.IO;
using System.Threading.Tasks;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.Domain.Services
{
    public class ImportFileService : IImportFileService
    {
        private readonly IProductRepository _productRepository;

        public ImportFileService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Import(Stream fileStream)
        {
            using (StreamReader sr = new StreamReader(fileStream))
            {
                await sr.ReadLineAsync();
                while (sr.Peek() != -1)
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = (await sr.ReadLineAsync())?.Trim().Replace("||","").Split("|");
                        int id = int.Parse(line[0]);
                        string name = line?[1];
                        decimal purchasePrice = decimal.Parse(line?[2]);
                        decimal sellPrice = decimal.Parse(line?[3]);
                        int ncm = int.Parse(line?[4]);
                        string category = line?[5];
                        DateTime dataCadastro = DateTime.Parse(line?[6]);

                        var products = new Product(id, name, purchasePrice, sellPrice, ncm, category,
                            dataCadastro);
                        await _productRepository.Add(products);
                    }
                }
            }
            return;
        }
    }
}