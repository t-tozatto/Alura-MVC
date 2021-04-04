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
        }).done(function (response) {
            let carrinho = response.carrinho;
            let itemPedido = response.item;
            let linhaItemPedido = $('[item-id=' + itemPedido.id + ']');
            linhaItemPedido.find('input').prop('value', itemPedido.quantidade);
            linhaItemPedido.find('[subtotal]').html((itemPedido.subtotal).duasCasasDecimais());

            $('[total]').html(carrinho.total.duasCasasDecimais());
            $('[numero-itens]').html('Total: ' + carrinho.item.length + ' itens');

            if (itemPedido.quantidade < 1)
                linhaItemPedido.remove();
        }).fail(function (fail) {
            debugger;
        });
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasasDecimais = function () {
    return this.toFixed(2).replace('.', ',');
}