package com.rentify.rentify.controller;

import com.rentify.rentify.model.Produto;
import com.rentify.rentify.repository.ProdutoRepository;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;
import java.util.UUID;

@RestController
@RequestMapping("produtos")
public class ProdutoController {
    private ProdutoRepository produtoRepository;

    public ProdutoController(ProdutoRepository produtoRepository) {
        this.produtoRepository = produtoRepository;
    }

    @PostMapping
    public Produto create(@RequestBody Produto produto) {
        var id = UUID.randomUUID().toString();
        produto.setId(id);
        produtoRepository.save(produto);
        return produto;
    }

    @GetMapping("{id}")
    public Produto getById(@PathVariable("id") String id) {
        return produtoRepository.findById(id).orElse(null);
    }

    @PutMapping("{id}")
    public void update(@PathVariable("id") String id,
                       @RequestBody Produto produto){
        produto.setId(id);
        produtoRepository.save(produto);
    }

    @DeleteMapping("{id}")
    public void delete(@PathVariable("id") String id) {
        produtoRepository.deleteById(id);
    }

    @GetMapping
    public List<Produto> getAll(){
        return produtoRepository.findAll();
    }

    @GetMapping("search")
    public List<Produto> search(@RequestParam(name = "nome") String nome){
        return produtoRepository.findByNome(nome);
    }
}
