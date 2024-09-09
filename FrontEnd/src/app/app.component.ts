import { Component, OnInit } from '@angular/core';
import { ApiService } from './services/api.service';
import { ProdutoDto } from './models/produtoDto';
import { PedidoDto } from './models/PedidoDto';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class AppComponent implements OnInit {
  pedidos: PedidoDto[] = [];
  produtos: ProdutoDto[] = [];
  showForm = false;
  produtosSelecionados = false;
  novoPedido: PedidoDto = { id: 0, nomeCliente: '', emailCliente: '', pago: false, valorTotal: 0, itensPedido: [] };
  selectedQuantities: { [key: number]: number } = {};

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    //this.getPedidos();
  }

  getProdutos() {
    this.apiService.getAllProdutos().subscribe({
      next: (response) => this.produtos = response,
      error: (err) => console.error('Erro ao obter produtos:', err.message)
    });
  }

  getPedidos() {
    this.apiService.getAllPedidos().subscribe({
      next: (response: PedidoDto[]) => this.pedidos = response,
      error: (err) => console.error('Erro ao obter pedidos:', err.message)
    });
  }

  toggleForm() {
    this.showForm = !this.showForm;
    if (!this.showForm) {
      this.resetForm();
    }
  }

  canSelectProdutos(): boolean {
    return this.novoPedido.nomeCliente.trim() !== '' && this.novoPedido.emailCliente.trim() !== '';
  }

  loadProdutos() {
    if (this.canSelectProdutos()) {
      this.getProdutos();
      this.produtosSelecionados = true;
    } else {
      alert('Por favor, preencha os campos Nome e Email do Cliente.');
    }
  }

  addProdutoToCarrinho(produtoId: number) {
    const quantidade = this.selectedQuantities[produtoId];
    if (quantidade > 0) {
      const itemExistente = this.novoPedido.itensPedido.find(item => item.idProduto === produtoId);
      if (itemExistente) {
        itemExistente.quantidade += quantidade;
      } else {
        const produto = this.produtos.find(p => p.id === produtoId);
        if (produto) {
          this.novoPedido.itensPedido.push({
            id: 0,
            idProduto: produto.id,
            nomeProduto: produto.nomeProduto,
            valorUnitario: produto.valor,
            quantidade: quantidade
          });
        }
      }
      this.selectedQuantities[produtoId] = 0;
      this.produtosSelecionados = this.novoPedido.itensPedido.length > 0;
      this.novoPedido.valorTotal = this.calcularTotalPedido();
    }
  }

  addPedido() {
    this.novoPedido.valorTotal = this.calcularTotalPedido();
    this.apiService.addPedido(this.novoPedido).subscribe({
      next: () => {
        alert('Pedido adicionado com sucesso!');
        this.resetForm();
        this.getPedidos();
      },
      error: (err) => alert('Erro ao adicionar pedido: ' + err.message)
    });
  }

  resetForm() {
    this.novoPedido = { id: 0, nomeCliente: '', emailCliente: '', pago: false, valorTotal: 0, itensPedido: [] };
    this.selectedQuantities = {};
    this.produtosSelecionados = false;
    this.showForm = false;
  }

  removeItem(index: number) {
    this.novoPedido.itensPedido.splice(index, 1);
    this.novoPedido.valorTotal = this.calcularTotalPedido();
    this.produtosSelecionados = this.novoPedido.itensPedido.length > 0;
  }

  updateValorUnitario(index: number) {
    const produtoId = this.novoPedido.itensPedido[index].idProduto;
    const produto = this.produtos.find(p => p.id === produtoId);
    if (produto) {
      this.novoPedido.itensPedido[index].valorUnitario = produto.valor;
      this.novoPedido.valorTotal = this.calcularTotalPedido();
    }
  }

  calcularTotalPedido(): number {
    return this.novoPedido.itensPedido.reduce((total, item) => total + (item.valorUnitario * item.quantidade), 0);
  }

  voltar() {
    this.showForm = false;
    this.pedidos = [];
  }
  
}
