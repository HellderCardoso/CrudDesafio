import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProdutoDto } from '../models/produtoDto';
import { PedidoDto } from '../models/PedidoDto';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrlProduto = 'https://localhost:44392/produto';  
  private apiUrlPedido = 'https://localhost:44392/pedido';  

  constructor(private http: HttpClient) { }

  getAllProdutos(): Observable<ProdutoDto[]> {
    return this.http.get<ProdutoDto[]>(this.apiUrlProduto);
  }

  getProdutoById(id: number): Observable<ProdutoDto> {
    return this.http.get<ProdutoDto>(`${this.apiUrlProduto}/${id}`);
  }

  getProdutoByName(name: string): Observable<ProdutoDto> {
    return this.http.get<ProdutoDto>(`${this.apiUrlProduto}/name/${name}`);
  }

  addProduto(produto: ProdutoDto): Observable<void> {
    return this.http.post<void>(this.apiUrlProduto, produto);
  }

  getAllPedidos(): Observable<PedidoDto[]> {
    return this.http.get<PedidoDto[]>(this.apiUrlPedido);
  }

  addPedido(pedido: PedidoDto): Observable<void> {
    return this.http.post<void>(this.apiUrlPedido, pedido);
  }
}
