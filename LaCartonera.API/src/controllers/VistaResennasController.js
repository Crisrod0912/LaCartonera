const VistaResennasService = require('../services/VistaResennasService');

class VistaResennasController {

    async getVistaResennas(req, res) {

        try {
            const resennas = await VistaResennasService.getVistaResennas();
            if (!resennas) {
                return res.status(404).json({ error: 'No se encontraron datos en la vista materializada' });
            }
            res.json(resennas);
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

    async actualizarVistaMaterializada(req, res) {

        try {
            await VistaResennasService.actualizarVistaMaterializada();
            res.status(200).json({ message: 'Vista materializada actualizada correctamente' });
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

}

module.exports = new VistaResennasController();
