const mongoose = require('mongoose');
const ContactosSchema = new mongoose.Schema({

    _id: { type: Number },
    telefono: { type: String },
    correo_electronico: { type: String },
    redes_sociales: {
        facebook: { type: String },
        twitter: { type: String },
        instagram: { type: String }
    }
    
},

    { collection: 'Contactos' }

);

module.exports = mongoose.model('Contactos', ContactosSchema)
