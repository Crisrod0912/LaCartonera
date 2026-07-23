const express = require('express');
const router = express.Router();
const ResennasController = require('../controllers/ResennasController');

router.get('/Resennas/:id', ResennasController.getResenna);
router.post('/Resennas', ResennasController.createResenna);
router.put('/Resennas/:id', ResennasController.updateResenna);
router.delete('/Resennas/:id', ResennasController.deleteResenna);

module.exports = router;
