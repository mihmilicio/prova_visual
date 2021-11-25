import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { FormaPagamento } from "src/app/models/forma-pagamento";
import { ItemVenda } from "src/app/models/item-venda";
import { Venda } from "src/app/models/venda";
import { FormaPagamentoService } from "src/app/services/forma-pagamento.service";
import { ItemService } from "src/app/services/item.service";
import { VendaService } from "src/app/services/venda.service";

@Component({
    selector: "app-finalizar",
    templateUrl: "finalizar.component.html",
    styleUrls: ["./finalizar.component.css"],
})
export class FinalizarComponent implements OnInit {
    nome?: string;
    formaPagamentoId?: number;
    formasPagamento: FormaPagamento[] = [];
    items: ItemVenda[] = [];

    constructor(
        private formaPagamentoService: FormaPagamentoService,
        private itemService: ItemService,
        private vendaService: VendaService,
        private router: Router
    ) {}

    ngOnInit() {
        this.formaPagamentoService.list().subscribe((result) => {
            this.formasPagamento = result;
        });

        const carrinhoId = localStorage.getItem("carrinhoId")! || "";
        this.itemService.getByCartId(carrinhoId).subscribe((result) => {
            this.items = result;
        });
    }

    cadastrar(): void {
        const venda: Venda = {
            cliente: this.nome,
            itens: this.items.map(
                (item) =>
                    <ItemVenda>{
                        produtoId: item.produtoId,
                        quantidade: item.quantidade,
                        preco: item.preco,
                        carrinhoId: item.carrinhoId,
                    }
            ),
            formaPagamentoId: this.formaPagamentoId,
        };
        this.vendaService.create(venda).subscribe((_) => {
            this.router.navigate([""]);
        });
    }
}
