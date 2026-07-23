const ContactosService = require('../services/ContactoNegocioService');

class ContactosController {

    async createContactos(req, res) {

        try {
            const Contactos = await ContactosService.createContactoNegocio(req.body);
            res.status(201).json(Contactos);
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

    async getContactos(req, res) {

        try {
            const Contactos = await ContactosService.getContactos(req.params.id);
            if (!Contactos) {
                return res.status(404).json({ error: 'Contactos not found' });
            }
            res.json(Contactos);
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

    async updateContactos(req, res) {

        try {
            const Contactos = await ContactosService.updateContactoNegocio(req.params.id, req.body);
            if (!Contactos) {
                return res.status(404).json({ error: 'Contactos not found' });
            }
            res.json(Contactos);
        } catch (err) {
            res.status(500).json({ error: err.message });
        }

    }

    async deleteContactos(req, res) {

        try {
            const Contactos = await ContactosService.deleteContactoNegocio(req.params.id);
            if (!Contactos) {
                return res.status(404).json({ error: 'Contactos not found' });
            }
            res.json({ message: 'Contactos deleted' });
        } catch (err) {
            res.status(500).json({ error: err.message});
        }

    }

}

module.exports = new ContactosController();
