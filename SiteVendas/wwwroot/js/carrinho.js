class Carrinho {
    clickIncremento(button) {       

        let data = this.getData(button);
        data.Quantidade++;
        this.postQuantidade(data);
    }

    clickDecremento(button) {
        let data = this.getData(button);
        data.Quantidade--;
        this.postQuantidade(data);
    }

    updateQuantidade(input) {
        let data = this.getData(input);
        this.postQuantidade(data);
    }

    getData(elemento) {
        var linhaDoItem = $(elemento).parents('[item-id]');
        var itemId = $(linhaDoItem).attr('item-id');
        var novaQuantidade = $(linhaDoItem).find('input').val();

        return {
            Id: itemId,
            Quantidade: novaQuantidade
        };
    }

    postQuantidade(data) {

        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/home/updatequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done (function (data) {
            

            let linhaDoItem = $('[item-id=' + data[1] + ']');
            linhaDoItem.find('input').val(data[2]);
            linhaDoItem.find('[subtotal]').html(data[0]);
            $('[numero-itens]').html('Total: ' + data[3] + ' itens');
            $('[total]').html(data[4]);
            if (data[2] === 0) {
                linhaDoItem.remove();
            }            
        });
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}