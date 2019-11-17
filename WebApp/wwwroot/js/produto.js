$("#div_container_produto").ready(() => {

    $('[data-toggle="tooltip"]').tooltip();

    produtojs.pesquisarId();

    $('#tblproduto').on('click', '.delete', function () {
        produtojs.excluir($(this));
    });

    $('#tblproduto').on('click', '.edit', function () {
        produtojs.editar($(this));
    });
});

var produtojs = {

    inserir: () => {
        $("#edtId").val("");
        $("#edtDescricao").val("");
        $("#edtPreco").val("");
        $("#edtEstoque").val("");
        $("#cmbCategoria").val(NaN);

        $("#campoOperacao").val("1");

        produtojs.listagemCategorias(() => {
            $("#addEditProdutoModal").modal();
        });
    },

    editar: (obj) => {
        var _id = $(obj).attr('data-id');
        var _descr = $(obj).attr('data-descricao');
        var _preco = $(obj).attr('data-preco');
        var _estoque = $(obj).attr('data-estoque');
        var _categoriaId = $(obj).attr('data-categoriaid');

        $("#edtId").val(_id);

        $("#edtDescricao").val(_descr);

        $("#edtPreco").val(_preco);

        $("#edtEstoque").val(_estoque);

        $("#campoOperacao").val("2");

        produtojs.listagemCategorias(() => {
            $("#cmbCategoria").val(_categoriaId);
            $("#addEditProdutoModal").modal();
        });

    },

    excluir: (obj) => {
        var _id = $(obj).attr('data-id');
        if (confirm("Deseja realmente excluir o registro selecionado?")) {
            produtojs.excluirRegistro(_id, () => {
                $(obj).closest('tr').fadeOut(300);

                
            });
        }
    },

    preencherTbl: (data) => {
        $("#tblproduto > tbody").empty();

        $(data).each(function () {

            $("#tblproduto > tbody")
                .append($('<tr>')
                    .append($('<td>').append(this.id))
                    .append($('<td>').append($.trim(this.nome)))
                    .append($('<td>').append($.trim(this.preco)))
                    .append($('<td>').append($.trim(this.nomeCategoria)))
                    .append($('<td>')
                        .append($('<a>')
                            .attr('class', 'edit')
                            .attr('data-id', this.id)
                            .attr('data-descricao', this.nome)
                            .attr('data-preco', this.preco)
                            .attr('data-categoriaid', this.categoriaId)
                            .attr('href', '#')
                            .append($('<i>')
                                .attr('class', 'material-icons')
                                .attr('data-toggle', 'tooltip')
                                .attr('title', 'Editar')
                                .append('&#xE254;')
                            )
                        )
                        .append($('<a>')
                            .attr('class', 'delete')
                            .attr('data-id', this.id)
                            .attr('href', '#')
                            .append($('<i>')
                                .attr('class', 'material-icons')
                                .attr('data-toggle', 'tooltip')
                                .attr('title', 'Excluir')
                                .append('&#xE872;')
                            )
                        )
                    )
                );
        });
    },

    listagemCategorias: (fncOk) => {
        var _url = sitejs.api.categoriaUrl();

        $.ajax({
            type: "GET",
            url: _url,
            context: this,
            success: function (response) {
                console.log(response);

                if (response != null) {
                    var data = response;
                    var selectbox = $('#cmbCategoria');
                    selectbox.find('option').remove();
                    $.each(data, function (i, d) {
                        $('<option>').val(d.id).text(d.descricao).appendTo(selectbox);
                    });
                }

                fncOk();

            },
            error: function (response) {
                alert("ERRO: " + response);
                console.log("ERRO: " + response);
            }
        });
    },

    pesquisarId: () => {
        var _url = "https://localhost:44391/api/produto/";
        $.ajax({
            type: "GET",
            url: _url,
            context: this,
            success: function (response) {
                console.log(response);
                produtojs.preencherTbl(response);
            },
            error: function (response) {
                alert("ERRO: " + response);
                console.log("ERRO: " + response);
            }
        });
    },

    gravarRegistro: () => {

        var _data = new Object();

        _data.id = $("#edtId").val();
        _data.descricao = $("#edtDescricao").val();
        _data.preco = $("#edtPreco").val();
        _data.estoque = $("#edtEstoque").val();
        _data.categoriaId = $("#cmbCategoria").val();

        var _operacao = $("#campoOperacao").val();

        var _method = _operacao == "1" ? "POST" : "PUT";
        var _url = sitejs.api.produtoUrl();

        $.ajax({
            url: _url,
            dataType: "json",
            type: _method,
            contentType: "application/json",
            data: JSON.stringify(_data),
            complete: (response) => {

                //if (response.statusCode == 200) {
                console.log(response);
                $("#addEditProdutoModal").modal('hide');
                //}
            },
            error: (response) => {
                console.log("ERRO: " + response);
            }
        });
    },

    excluirRegistro: (id, fncOk) => {
        var _url = "https://localhost:44391/api/produto/";
        $.ajax({
            type: "DELETE",
            url: _url +  id,
            context: this,
            complete: (response) => {

                if (response.statusCode == 200) {
                    console.log(response);
                    fncOk();
                }
            },
            error: (response) => {
                alert("ERRO: " + response);
                console.log("ERRO: " + response);
            }
        });
    }

};

