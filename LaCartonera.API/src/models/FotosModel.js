const mongoose = require('mongoose');
const FotosSchema = new mongoose.Schema({

    _id: { type: Number },
    id_local: { type: Number, ref : 'Locales' },
    ruta_imagen: { type: String }
    
},

    { collection: 'Fotos' }

);

module.exports = mongoose.model('Fotos', FotosSchema)
