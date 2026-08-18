const mongoose = require('mongoose');
const ContactoNegocioSchema = new mongoose.Schema({

    _id: { type: Number },
    id_local: { type: Number, ref : 'Locales' },
    email_negocio: { type: String },
    telefono_negocio: { type: String },
    disponibilidad: { type: String }

},

    { collection: 'ContactoNegocio' }

);

module.exports = mongoose.model('ContactoNegocio', ContactoNegocioSchema)
