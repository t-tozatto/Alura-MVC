class Carrinho {
    IncrementoQuantidade(btnIncremento) {
        this.AumentarDiminuirQuantidade(btnIncremento, true);
    }

    DecrementoQuantidade(btnDecremento) {
        this.AumentarDiminuirQuantidade(btnDecremento, false);
    }

    AtualizarQuantidade(input) {
        this.PutQuantidadeItem(this.GetData(input));
    }

    GetData(element) {
        var divProduto = $(element).parents('[item-id]');
        const idItem = $(divProduto).attr('item-id');
        let quantidade = $(divProduto).find('input').val();

        return {
            Id: idItem,
            Quantidade: quantidade
        };
    }

    AumentarDiminuirQuantidade(element, aumentar) {
        var item = this.GetData(element);

        if (aumentar)
            item.Quantidade++;
        else
            item.Quantidade--;

        this.PutQuantidadeItem(item);
    }

    PutQuantidadeItem(data) {
        $.ajax({
            url: '/pedido/AtualizarQuantidadeItem',
            contentType: 'application/json; charset=utf-8',
            type: 'PUT',
            data: JSON.stringify(data)
        });
    }
}

var carrinho = new Carrinho();