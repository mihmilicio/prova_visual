import { FormaPagamento } from "./forma-pagamento";
import { ItemVenda } from "./item-venda";

export interface Venda {
    vendaId?: number;
    cliente?: string;
    itens?: ItemVenda[];
    formaPagamento?: FormaPagamento;
    formaPagamentoId?: number;
    criadoEm?: string;
}
