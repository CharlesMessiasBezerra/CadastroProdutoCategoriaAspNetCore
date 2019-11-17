var sitejs = {
    api: {
        baseUrl: () => "http://localhost:44391/api/",
        categoriaUrl: () => sitejs.api.baseUrl() + "categoria/",
        produtoUrl: () => sitejs.api.baseUrl() + "produto/"
    }
};
