using DTOs;
using PackingService.DTOs;
using PackingService.Entities;

namespace PackingService.Service.Utils
{
    public class BoxValidator
    {

        private IEnumerable<BoxesDTO> SelectOptimalBox(
            List<ProductDTO> orderedProducts,
            IEnumerable<Boxes> boxesAvailable,
            Dictionary<string, Boxes> boxesDict)
        {
            orderedProducts = orderedProducts
                .OrderByDescending(p => p.Dimensoes.Volume)
                .ToList();

            var boxesOrders = new List<BoxesDTO>();

            foreach (var produto in orderedProducts)
            {
                BoxesDTO? caixaExistente = null;

                foreach (var box in boxesOrders)
                {
                    var produtosNaCaixa = orderedProducts.Where(p => box.Produtos.Contains(p.ProdutoId)).ToList();
                    var dimensoesOcupadas = CalculateOccupation(produtosNaCaixa);

                    var dimensoesCaixa = GetBoxDimensions(boxesDict, box.CaixaId);

                    if (ValidadeCaixa(dimensoesOcupadas, dimensoesCaixa, produto.Dimensoes))
                    {
                        caixaExistente = box;
                        break;
                    }
                }

                if (caixaExistente != null)
                {
                    caixaExistente.Produtos.Add(produto.ProdutoId);
                    continue;
                }

                var caixasQueCabem = boxesAvailable
                    .Where(c => ProdutoCabeNaCaixa(produto.Dimensoes, new DimensionDTO
                    {
                        Altura = c.Altura,
                        Largura = c.Largura,
                        Comprimento = c.Comprimento
                    }))
                    .ToList();

                if (!caixasQueCabem.Any())
                {
                    boxesOrders.Add(new BoxesDTO
                    {
                        CaixaId = null,
                        Produtos = new List<string> { produto.ProdutoId },
                        Observacao = "Produto não cabe em nenhuma caixa disponível."
                    });
                    continue;
                }

                var modeloCaixa = caixasQueCabem.First();

                boxesOrders.Add(new BoxesDTO
                {
                    CaixaId = modeloCaixa.Nome,
                    Produtos = new List<string> { produto.ProdutoId }
                });
            }

            return boxesOrders;
        }

        private bool ProdutoCabeNaCaixa(DimensionDTO produto, DimensionDTO caixa)
        {
            var orientacoes = new List<(int A, int L, int C)>
            {
                (produto.Altura, produto.Largura, produto.Comprimento),
                (produto.Largura, produto.Comprimento, produto.Altura),
                (produto.Comprimento, produto.Altura, produto.Largura),
                (produto.Altura, produto.Comprimento, produto.Largura),
                (produto.Largura, produto.Altura, produto.Comprimento),
                (produto.Comprimento, produto.Largura, produto.Altura)
            };

            return orientacoes.Any(o =>
                o.A <= caixa.Altura &&
                o.L <= caixa.Largura &&
                o.C <= caixa.Comprimento
            );
        }

        private bool ValidadeCaixa(
            DimensionDTO dimensoesOcupadas,
            DimensionDTO dimensoesCaixa,
            DimensionDTO dimensaoProduto)
        {
            return ProdutoCabeNaCaixa(produto: dimensaoProduto, caixa: dimensoesCaixa) &&
                   (dimensoesOcupadas.Comprimento + dimensaoProduto.Comprimento <= dimensoesCaixa.Comprimento) &&
                   (dimensoesOcupadas.Altura + dimensaoProduto.Altura <= dimensoesCaixa.Altura);
        }

        private DimensionDTO CalculateOccupation(List<ProductDTO> produtos)
        {
            var larguraMaxima = produtos.Any() ? produtos.Max(p => p.Dimensoes.Largura) : 0;
            var comprimentoTotal = produtos.Sum(p => p.Dimensoes.Comprimento);
            var alturaEmpilhada = produtos.Sum(p => p.Dimensoes.Altura);

            return new DimensionDTO
            {
                Largura = larguraMaxima,
                Comprimento = comprimentoTotal,
                Altura = alturaEmpilhada
            };
        }

        private DimensionDTO GetBoxDimensions(Dictionary<string, Boxes> boxesDict, string caixaId)
        {
            if (!boxesDict.TryGetValue(caixaId, out var dimensions))
            {
                return new DimensionDTO(); // fallback vazio
            }

            return new DimensionDTO
            {
                Altura = dimensions.Altura,
                Comprimento = dimensions.Comprimento,
                Largura = dimensions.Largura
            };
        }
    }
}
