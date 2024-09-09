export interface PedidoDto {
  id: number;
  nomeCliente: string;
  emailCliente: string;
  pago: boolean;
  valorTotal: number;
  itensPedido: {
    id: number;
    idProduto: number;
    nomeProduto: string;
    valorUnitario: number;
    quantidade: number;
  }[];
}
