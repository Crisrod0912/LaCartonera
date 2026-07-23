const Usuarios = require('../models/UsuariosModel');
const bcrypt = require('bcryptjs');
const dotenv = require('dotenv');

class UsuariosService {

    async createUsuarios(data) {

        const Usuario = new Usuarios(data);
        Usuario.contrasenna = await this.hashPassword(Usuario.contrasenna);
        await Usuario.save();
        return Usuario;

    }

    async getUsuarios(id) {
        
        if (id !=0) {
            return await Usuarios.findById(id);
        }
        return await Usuarios.find();

    }

    async updateUsuarios(id, data) {

        let updateData = data;
        if (updateData.contrasenna != null) {
            updateData.contrasenna = await this.hashPassword(updateData.contrasenna);
        } else {
            if (id !=0) {
                const passwordUser = await this.getUsuarios(id)
                updateData.contrasenna = passwordUser.contrasenna
            }
        }
        return await Usuarios.findByIdAndUpdate(id, updateData, { new: true });

    }

    async deleteUsuarios(id) {

        return await Usuarios.findByIdAndDelete(id);

    }

    async hashPassword(password) {

        dotenv.config();
        const salt = await bcrypt.genSalt(parseInt(process.env.salt));
        const hashedPassword = await bcrypt.hash(password, salt);
        return hashedPassword;

    }

}

module.exports = new UsuariosService();
