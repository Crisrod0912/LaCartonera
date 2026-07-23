const mongoose = require('mongoose');
const ResennasSchema = new mongoose.Schema({

    _id: { type: Number, require: true },
    id_usuario: { type: Number, required: true },
    id_local: { type: Number, required: true },
    calificacion: { type: Number, required: true },
    comentario: { type: String, required: true }

}, 

{ collection: 'Resennas' }

);

module.exports = mongoose.model('Resennas', ResennasSchema);
