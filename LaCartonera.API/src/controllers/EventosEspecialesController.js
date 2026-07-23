const EventosEsecialesService = require('../services/EventosEspecialesService');

class EventosEspecialesController {

    async createEventosEspeciales(req, res) {

        try {
            const EventosEspeciales = await EventosEsecialesService.createEventosEspeciales(req.body);
            res.status(201).json(EventosEspeciales);
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

    async getEventosEspeciales(req, res) {

        try {
            const EventosEspeciales = await EventosEsecialesService.getEventosEspeciales(req.params.id);
            if (!EventosEspeciales) {
                return res.status(404).json({ error: 'EventosEspeciales not found' });
            }
            res.json(EventosEspeciales);
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

    async updateEventosEspeciales(req, res) {

        try {
            const EventosEspeciales = await EventosEsecialesService.updateEventosEspeciales(req.params.id, req.body);
            if (!EventosEspeciales) {
                return res.status(404).json({ error: 'EventosEspeciales not found' });
            }
            res.json(EventosEspeciales);
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

    async deleteEventosEspeciales(req, res) {

        try {
            const EventosEspeciales = await EventosEsecialesService.deleteEventosEspeciales(req.params.id);
            if (!EventosEspeciales) {
                return res.status(404).json({ error: 'EventosEspeciales not found' });
            }
            res.json({ message: 'EventosEspeciales deleted' });
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

}

module.exports = new EventosEspecialesController();
