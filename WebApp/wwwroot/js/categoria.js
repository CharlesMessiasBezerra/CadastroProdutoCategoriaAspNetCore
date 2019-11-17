$("#div_container_categoria").ready(() => {

    $('[data-toggle="tooltip"]').tooltip();

    categoriajs.pesquisarId();

    $('#tblcategoria').on('click', '.delete', () => {
        categoriajs.excluir($(this));
    });

    $('#tblcategoria').on('click', '.edit', () => {
        categoriajs.editar($(this));
    });
});

var categoriajs = {

    inserir: () => {
        $("#edtId").val("");
        $("#edtDescricao").val("");
        $("#addEditCategoriaModal").modal();
    },

    editar: (obj) => {
        var _id = $(obj).attr("data-id");
        var _descr = $(obj).attr('data-descricao');

        $("#edtId").val(_id);

        $("#edtDescricao").val(_descr);

        $("#addEditCategoriaModal").modal();
    },

    excluir: (obj) => {
        var _id = $(obj).attr("data-id");
        if (confirm("Deseja realmente excluir o registro selecionado?")) {
            categoriajs.excluirRegistro(_id, () => {
                $(obj).closest('tr').fadeOut(300);
            });
        }
    },
 
    preencherTbl: (data) => {
        $("#tblcategoria > tbody").empty();

        $(data).each(function() {

            $("#tblcategoria > tbody")
                .append($('<tr>')
                    .append($('<td>').append(this.id))
                    .append($('<td>').append($.trim(this.nome)))
                    .append($('<td>')
                        .append($('<a>')
                            .attr('class', 'edit')
                            .attr('data-id', this.id)
                            .attr('data-descricao', this.nome)
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

    pesquisarId: () => {
        var _url = sitejs.api.categoriaUrl();

        $.ajax({
            type: "GET",
            url: "https://localhost:44391/api/categoria/",
            context: this,
            success: function (response) {
                console.log(response);
                categoriajs.preencherTbl(response);
            },
            error: function (response) {
                alert("ERRO: " + response);
                console.log("ERRO: " + response);
            }
        });
    },

    gravarRegistro: () => {

        if ($("#edtDescricao").val().length == 0) {
            alert("Informe a descrição.");
            return;
        }

        var _data = new Object();

        if ($("#edtId").val().length > 0) {
            _data.id = $("#edtId").val();
        }
        _data.Nome = $("#edtDescricao").val();

        var postData = { "Nome": $("#edtDescricao").val() };

        var _method = $("#edtId").val().length > 0 ? "PUT" : "POST";
        var _url = sitejs.api.categoriaUrl();

        $.ajax({
            url: "https://localhost:44391/api/categoria/",
            dataType: "json",
            type: _method,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(postData),
            complete: (response) => {

                if (response.statusCode == 200) {
                    console.log(response);
                    $("#addEditCategoriaModal").modal('hide');
                }
            },
            error: (response) => {
                console.log("ERRO: " + response);
            }
        });
    },

    excluirRegistro: (id, fncOk) => {        
        $.ajax({
            type: "DELETE",
            url: "https://localhost:44391/api/categoria/"+ id,
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

