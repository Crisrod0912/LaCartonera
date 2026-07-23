const express = require('express');
const router = express.Router();
const VistaResennasController = require('../controllers/VistaResennasController');

router.get('/vista-resennas', VistaResennasController.getVistaResennas);

router.post('/actualizar-vista', VistaResennasController.actualizarVistaMaterializada);

module.exports = router;
