const mongoose = require('mongoose');
const LocalesSchema = new mongoose.Schema({

    _id: { type: Number },
    nombre: { type: String },
    id_categoria: { type: Number },
    descripcion: { type: String }
    
},

    { collection: 'Locales' }

);

module.exports = mongoose.model('Locales', LocalesSchema)
