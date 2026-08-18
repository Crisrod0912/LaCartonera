const express = require('express');
const router = express.Router();
const CategoriasController = require('../controllers/CategoriasController');

router.get('/Categorias/:id', CategoriasController.getCategorias);
router.get('/Categorias/buscar/:Nombre', CategoriasController.getPorNombreCategorias);
router.post('/Categorias', CategoriasController.createCategorias);
router.put('/Categorias/:id', CategoriasController.updateCategorias);
router.delete('/Categorias/:id', CategoriasController.deleteCategorias);

module.exports = router;
