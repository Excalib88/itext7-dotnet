/*
This file is part of the iText (R) project.
Copyright (c) 1998-2019 iText Group NV
Authors: iText Software.

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License version 3
as published by the Free Software Foundation with the addition of the
following permission added to Section 15 as permitted in Section 7(a):
FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
OF THIRD PARTY RIGHTS

This program is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program; if not, see http://www.gnu.org/licenses or write to
the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
Boston, MA, 02110-1301 USA, or download the license from the following URL:
http://itextpdf.com/terms-of-use/

The interactive user interfaces in modified source and object code versions
of this program must display Appropriate Legal Notices, as required under
Section 5 of the GNU Affero General Public License.

In accordance with Section 7(b) of the GNU Affero General Public License,
a covered work must retain the producer line in every PDF that is created
or manipulated using iText.

You can be released from the requirements of the license by purchasing
a commercial license. Buying such a license is mandatory as soon as you
develop commercial activities involving the iText software without
disclosing the source code of your own applications.
These activities include: offering paid services to customers as an ASP,
serving PDFs on the fly in a web application, shipping iText with a closed
source product.

For more information, please contact iText Software Corp. at this
address: sales@itextpdf.com
*/
using System;
using System.Collections.Generic;
using iText.Kernel.Pdf.Canvas;
using iText.StyledXmlParser.Css.Util;
using iText.Svg;
using iText.Svg.Renderers;

namespace iText.Svg.Renderers.Impl {
    /// <summary>
    /// <see cref="iText.Svg.Renderers.ISvgNodeRenderer"/>
    /// implementation for the &lt;line&gt; tag.
    /// </summary>
    public class LineSvgNodeRenderer : AbstractSvgNodeRenderer {
        public override void DoDraw(SvgDrawContext context) {
            PdfCanvas canvas = context.GetCurrentCanvas();
            canvas.WriteLiteral("% line\n");
            if (attributesAndStyles.Count > 0) {
                float x1 = 0f;
                float y1 = 0f;
                float x2 = 0f;
                float y2 = 0f;
                if (attributesAndStyles.ContainsKey(SvgConstants.Attributes.X1)) {
                    x1 = GetAttribute(attributesAndStyles, SvgConstants.Attributes.X1);
                }
                if (attributesAndStyles.ContainsKey(SvgConstants.Attributes.Y1)) {
                    y1 = GetAttribute(attributesAndStyles, SvgConstants.Attributes.Y1);
                }
                if (attributesAndStyles.ContainsKey(SvgConstants.Attributes.X2)) {
                    x2 = GetAttribute(attributesAndStyles, SvgConstants.Attributes.X2);
                }
                if (attributesAndStyles.ContainsKey(SvgConstants.Attributes.Y2)) {
                    y2 = GetAttribute(attributesAndStyles, SvgConstants.Attributes.Y2);
                }
                canvas.MoveTo(x1, y1).LineTo(x2, y2);
            }
        }

        public override bool CanElementFill() {
            return false;
        }

        internal virtual float GetAttribute(IDictionary<String, String> attributes, String key) {
            String value = attributes.Get(key);
            if (value != null && !String.IsNullOrEmpty(value)) {
                return CssUtils.ParseAbsoluteLength(attributes.Get(key));
            }
            return 0;
        }

        public override ISvgNodeRenderer CreateDeepCopy() {
            LineSvgNodeRenderer copy = new LineSvgNodeRenderer();
            DeepCopyAttributesAndStyles(copy);
            return copy;
        }
    }
}
