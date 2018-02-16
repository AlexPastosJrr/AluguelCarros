$(document).ready(function () {
    mascaras();
    tabelaCarros();
    tabelaCarrosAluguel();
    ModalExcluir();
});


function SalvarCarro() {
    $("btnSalvar").submit(function (event) {
        event.preventDefault();

        $.ajax({
            method: 'post',
            url: "Carro/Novo",
            data: $("#formCadastroCarro").serialize()
        });
    });
}



function SalvarAluguel() {
    $("btnSalvarAluguel").submit(function (event) {
        event.preventDefault();

        $.ajax({
            method: 'post',
            url: "Aluguel/Novo",
            data: $("formAluguel").serialize()
        });
    });
}

function ModalExcluir() {
    $("#btnExcluir").click(function (event) {
        console.log(event);
        var confirma = confirm('Deseja realmente excluir esse Carro ?');
        if (confirma) {
            return confirm('Carro excluido com Sucesso !!!');
            window.location.reload();
        } else {
            event.preventDefault();
        }
    });
}


function tabelaCarros() {
    $('#tabelaCarrosCadastrados').dataTable({
        ajax: {
            method: "POST",
            url: "Carro/ListarTodos",
            contentType: "application/json; charset=utf-8",
            dataType: "Json",
        },
        columns: [
            { "data": "Descricao" },
            { "data": "PlacaDoVeiculo" },
            { "data": "Ano" },
            {
                "data": "Combustivel", "render": function (data, type, row) {
                    if (data === 0) {
                        return "Gasolina"
                    }
                    if (data === 1) {
                        return "Etanol"
                    }
                    if (data === 2) {
                        return "Diesel"
                    }
                    if (data === 3) {
                        return "Flex"
                    }
                
                }
            },
            { "data": "Cor" },
            { "data": "Marca" },
            {
                "data": "", "render": function (data, type, row) {

                    var editBtn = '<a type="button" href="/Carro/Alterar/' + row.Id + '" <span class="glyphicon glyphicon-pencil"></span></a>'
                    return editBtn;
                }
            },
            {
                "data": "", "render": function (data, type, row) {

                    var deleteBtn = '<a type="button" id="btnExcluir" href="/Carro/Excluir/' + row.Id + '" <span class="glyphicon glyphicon-trash"></span></a>'
                    return deleteBtn;
                }
            },
        ]
    });
}


function tabelaCarrosAluguel() {
    $('#tabelaAluguel').dataTable({
        ajax: {
            method: "POST",
            url: "Carro/ListarTodos",
            contentType: "application/json; charset=utf-8",
            dataType: "Json",
        },
        columns: [

            { "data": "Descricao" },
            { "data": "PlacaDoVeiculo" },
            { "data": "Ano" },
            {
                "data": "Combustivel", "render": function (data, type, row) {
                    if (data === 0) {
                        return "Gasolina"
                    }
                    if (data === 1) {
                        return "Etanol"
                    }
                    if (data === 2) {
                        return "Diesel"
                    }
                    if (data === 3) {
                        return "Flex"
                    }

                }
            },
            { "data": "Cor" },
            { "data": "Marca" },
            {
                "data": "IsAlugado", "render": function (data, type, row) {
                    if (data === false) {
                        return "Disponivel"
                    }
                    if (data === true) {
                        return "Alugado"
                    }
                }
            },
            {
                "data": "", "render": function (data, type, row) {
                    var editBtn;
                    if (row.IsAlugado === false) {
                        return editBtn = '<a type="button" href="/Aluguel/Novo" <span class=" btn btn-success">Alugar</span></a>'
                    }
                    else {
                        editBtn = '<a type="button" onclick="javascript:Devolver('
                            + "'XXX'"
                            + ')"><span class="btn btn-danger">Devolver</span></a>';
                        editBtn = editBtn.replace('XXX', row.PlacaDoVeiculo);
                        return editBtn
                    }
                }
            },
        ]
    });
}

function Devolver(data) {
    $.ajax({
        method: 'post',
        url: "Aluguel/Devolver",
        data: {data : data}
    });
}


function mascaras() {
    $("#placa").mask('AAA9999');
    $("#cpf").mask('999.999.999-99');
}
