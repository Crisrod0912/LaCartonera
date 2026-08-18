const mongoose = require('mongoose');
const CategoriasSchema = new mongoose.Schema({

    _id: { type: Number },
    Nombre: { type: String },
    Descripcion: { type: String },
    Ejemplos: [{ type: String }]

},

    { collection: 'Categorias' }

);

module.exports = mongoose.model('Categorias', CategoriasSchema);
