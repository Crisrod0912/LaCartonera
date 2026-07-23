const ResennasService = require('../services/ResennasService');

class ResennasController {

    async createResenna(req, res) {

        try {
            const resenna = await ResennasService.createResenna(req.body);
            res.status(201).json(resenna);
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

    async getResenna(req, res) {

        try {
            const resenna = await ResennasService.getResenna(req.params.id);
            if (!resenna) {
                return res.status(404).json({ error: 'Resenna not found' });
            }
            res.json(resenna);
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

    async updateResenna(req, res) {

        try {
            const resenna = await ResennasService.updateResenna(req.params.id, req.body);
            if (!resenna) {
                return res.status(404).json({ error: 'Resenna not found' });
            }
            res.json(resenna);
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

    async deleteResenna(req, res) {

        try {
            const resenna = await ResennasService.deleteResenna(req.params.id);
            if (!resenna) {
                return res.status(404).json({ error: 'Resenna not found' });
            }
            res.json({ message: 'Resenna deleted' });
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

}

module.exports = new ResennasController();
